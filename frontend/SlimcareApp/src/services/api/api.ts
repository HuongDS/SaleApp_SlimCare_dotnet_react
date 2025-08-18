// src/api.ts
import axios from "axios";

export const api = axios.create({
    baseURL: "https://localhost:7036",
    withCredentials: false, // no cookie
});