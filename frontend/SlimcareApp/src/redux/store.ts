import { configureStore } from "@reduxjs/toolkit";
import authSlice from "./authSlice";
import productsSlice from "./productsSlice";
import productSlice from "./productSlice";

export const store = configureStore({
  reducer: {
    auth: authSlice,
    products: productsSlice,
    product: productSlice,
  },
});

export type RootState = ReturnType<
  typeof store.getState
>;
export type AppDispatch = typeof store.dispatch;
