// src/api.ts
import axios from "axios";

export const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE,
  withCredentials: false,
});

console.log(
  "API BASE =",
  import.meta.env.VITE_API_BASE
);
