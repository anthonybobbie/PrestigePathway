import axios, { AxiosRequestConfig, AxiosInstance, AxiosError } from "axios";
import config from "../../config";

// Initialize axios instance
const axiosInstance: AxiosInstance = axios.create({
  baseURL: config.API_BASE_URL,
  timeout: 10000, // Increased timeout for better UX
  headers: {
    "Content-Type": "application/json",
  },
});

// Enhanced request interceptor
axiosInstance.interceptors.request.use(
  (config: any) => {
    const token = getAuthToken();
    const mergedHeaders = {
      ...config.headers,
      ...(token ? { Authorization: `Bearer ${token}` } : {}),
    };

    return {
      ...config,
      headers: mergedHeaders,
    };
  },
  (error) => Promise.reject(error)
);

// Add response interceptor for error handling
axiosInstance.interceptors.response.use(
  (response) => response,
  (error: AxiosError) => {
    if (error.response?.status === 401) {
      // Auto-logout on 401 Unauthorized
      clearAuth();
    }
    return Promise.reject(error);
  }
);

// Auth token management
const getAuthToken = (): string | null => {
  try {
    return localStorage.getItem("authToken");
  } catch (error) {
    console.error("Error accessing localStorage:", error);
    return null;
  }
};

const storeAuthToken = (token: string): void => {
  localStorage.setItem("authToken", token);
};

const clearAuth = (): void => {
  localStorage.removeItem("authToken");
  delete axiosInstance.defaults.headers.common["Authorization"];
};

const apiService = {
  // Auth methods
  login: async (username: string, password: string): Promise<void> => {
    try {
      const response = await axiosInstance.post<{ token: string }>(
        "/auth/login",
        { username, password }
      );

      if (response.data.token) {
        storeAuthToken(response.data.token);
      }
    } catch (error) {
      clearAuth();
      throw error;
    }
  },

  logout: async (): Promise<void> => {
    try {
      await axiosInstance.post("/auth/logout");
    } finally {
      clearAuth();
    }
  },

  isAuthenticated: (): boolean => {
    return !!getAuthToken();
  },

  // Data methods
  get: async <T>(
    endpoint: string,
    configOptions?: AxiosRequestConfig
  ): Promise<T> => {
    const response = await axiosInstance.get<T>(endpoint, configOptions);
    return response.data;
  },

  post: async <TRequest, TResponse>(
    endpoint: string,
    data: TRequest,
    configOptions?: AxiosRequestConfig
  ): Promise<TResponse> => {
    const response = await axiosInstance.post<TResponse>(
      endpoint,
      data,
      configOptions
    );
    return response.data;
  },

  put: async <TRequest, TResponse>(
    endpoint: string,
    data: TRequest,
    configOptions?: AxiosRequestConfig
  ): Promise<TResponse> => {
    const response = await axiosInstance.put<TResponse>(
      endpoint,
      data,
      configOptions
    );
    return response.data;
  },

  delete: async <T>(
    endpoint: string,
    configOptions?: AxiosRequestConfig
  ): Promise<T> => {
    const response = await axiosInstance.delete<T>(endpoint, configOptions);
    return response.data;
  },
};

export default apiService;
