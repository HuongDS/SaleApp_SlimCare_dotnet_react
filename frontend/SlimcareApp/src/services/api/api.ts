// src/api.ts
import axios from "axios";
import { getAccessToken } from "../../token/tokenStore";

export const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE,
  withCredentials: false, // no cookie
  timeout: 30000, // 30 seconds
});

// Interceptors. Gắn accessToken vào request
api.interceptors.request.use((config) => {
  const accessToken = getAccessToken();
  if (accessToken) {
    config.headers.Authorization = `Bearer ${accessToken}`;
  }
  return config;
});
