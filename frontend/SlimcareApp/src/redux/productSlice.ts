import {
  createSlice,
  type PayloadAction,
} from "@reduxjs/toolkit";
import type { Product } from "../model/ProductModel";

type ProductState = {
  product: Product | null;
};

const initialState: ProductState = {
  product: null,
};

const productSlice = createSlice({
  name: "product",
  initialState,
  reducers: {
    setProduct: (
      state,
      action: PayloadAction<Product>
    ) => {
      state.product = action.payload;
    },
  },
});

export default productSlice.reducer;
export const { setProduct } =
  productSlice.actions;
