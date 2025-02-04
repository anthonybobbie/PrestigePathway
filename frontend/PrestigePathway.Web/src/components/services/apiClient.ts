import axios from "axios";

const apiClient = axios.create({
  baseURL: "http://localhost:5000/api", // Backend API URL
});

export default apiClient;