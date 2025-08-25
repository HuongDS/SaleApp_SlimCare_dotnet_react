// src/api.ts
import axios from "axios";

export const api = axios.create({
  baseURL: "https://localhost:7036", // phải ra string, không undefined
  withCredentials: false, // bạn đang không dùng cookie
});

// debug nếu cần:
console.log(
  "API BASE =",
  import.meta.env.VITE_API_BASE
);
