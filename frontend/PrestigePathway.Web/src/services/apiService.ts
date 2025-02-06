import axios, { AxiosRequestConfig, AxiosInstance, AxiosError, CancelTokenSource } from 'axios';
import config from '../../config'; // Import the config file

// Create a custom Axios instance with default configurations
const axiosInstance: AxiosInstance = axios.create({
  baseURL: config.API_BASE_URL,
  timeout: 5000, // Set a default timeout of 5 seconds
  headers: {
    'Content-Type': 'application/json',
    // Add other default headers here if needed
  },
  withCredentials: true, // Ensure cookies are sent with each request
});

// Request interceptor to add authorization headers or other configurations
axiosInstance.interceptors.request.use(
  (requestConfig) => {
    // Additional configurations or headers can be added here if necessary
    return requestConfig;
  },
  (error) => {
    // Handle request errors
    console.error('Request Error:', error);
    return Promise.reject(error);
  }
);

// Response interceptor to handle responses and errors globally
axiosInstance.interceptors.response.use(
  (response) => response,
  (error: AxiosError) => {
    handleApiError(error);
    return Promise.reject(error);
  }
);

/**
 * Handles API errors for debugging and user notifications.
 */
const handleApiError = (error: AxiosError) => {
  if (axios.isAxiosError(error)) {
    console.error('API Error:', {
      message: error.message,
      response: error.response?.data,
      status: error.response?.status,
      headers: error.response?.headers,
    });
    // Optionally, implement user-friendly notifications here
  } else {
    console.error('Unexpected Error:', error);
  }
};

const apiService = {
  /**
   * Generic GET request
   */
  get: async <T>(endpoint: string, configOptions?: AxiosRequestConfig, cancelToken?: CancelTokenSource): Promise<T> => {
    try {
      const response = await axiosInstance.get<T>(endpoint, { ...configOptions, cancelToken: cancelToken?.token });
      return response.data;
    } catch (error) {
      // Error handling is managed by the interceptor
      throw error;
    }
  },

  /**
   * Generic POST request
   */
  post: async <TRequest, TResponse>(
    endpoint: string,
    data: TRequest,
    configOptions?: AxiosRequestConfig,
    cancelToken?: CancelTokenSource
  ): Promise<TResponse> => {
    try {
      const response = await axiosInstance.post<TResponse>(endpoint, data, { ...configOptions, cancelToken: cancelToken?.token });
      return response.data;
    } catch (error) {
      // Error handling is managed by the interceptor
      throw error;
    }
  },

  /**
   * Generic PUT request
   */
  put: async <TRequest, TResponse>(
    endpoint: string,
    data: TRequest,
    configOptions?: AxiosRequestConfig,
    cancelToken?: CancelTokenSource
  ): Promise<TResponse> => {
    try {
      const response = await axiosInstance.put<TResponse>(endpoint, data, { ...configOptions, cancelToken: cancelToken?.token });
      return response.data;
    } catch (error) {
      // Error handling is managed by the interceptor
      throw error;
    }
  },

  /**
   * Generic DELETE request
   */
  delete: async (endpoint: string, configOptions?: AxiosRequestConfig, cancelToken?: CancelTokenSource): Promise<boolean> => {
    try {
      await axiosInstance.delete(endpoint, { ...configOptions, cancelToken: cancelToken?.token });
      return true;
    } catch (error) {
      // Error handling is managed by the interceptor
      return false;
    }
  },
};

export default apiService;
