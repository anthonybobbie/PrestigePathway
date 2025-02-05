import axios, { AxiosRequestConfig } from "axios";
import config from "../../config"; // Import the config file

const apiService = {
  /**
   * Generic GET request
   */
  get: async <T>(endpoint: string, configOptions?: AxiosRequestConfig): Promise<T> => {
    try {
      const response = await axios.get<T>(`${config.API_BASE_URL}${endpoint}`, configOptions);
      return response.data;
    } catch (error) {
      handleApiError(error);
      throw error;
    }
  },

  /**
   * Generic POST request
   */
  post: async <TRequest, TResponse>(
    endpoint: string,
    data: TRequest,
    configOptions?: AxiosRequestConfig
  ): Promise<TResponse> => {
    try {
      const response = await axios.post<TResponse>(`${config.API_BASE_URL}${endpoint}`, data, configOptions);
      return response.data;
    } catch (error) {
      handleApiError(error);
      throw error;
    }
  },

  /**
   * Generic PUT request
   */
  put: async <TRequest, TResponse>(
    endpoint: string,
    data: TRequest,
    configOptions?: AxiosRequestConfig
  ): Promise<TResponse> => {
    try {
      const response = await axios.put<TResponse>(`${config.API_BASE_URL}${endpoint}`, data, configOptions);
      return response.data;
    } catch (error) {
      handleApiError(error);
      throw error;
    }
  },

  /**
   * Generic DELETE request
   */
  delete: async (endpoint: string, configOptions?: AxiosRequestConfig): Promise<boolean> => {
    try {
      await axios.delete(`${config.API_BASE_URL}${endpoint}`, configOptions);
      return true;
    } catch (error) {
      handleApiError(error);
      return false;
    }
  },
};

/**
 * Handles API errors for debugging.
 */
const handleApiError = (error: any) => {
  if (axios.isAxiosError(error)) {
    console.error("API Error:", error.response?.data || error.message);
  } else {
    console.error("Unexpected Error:", error);
  }
};

export default apiService;
