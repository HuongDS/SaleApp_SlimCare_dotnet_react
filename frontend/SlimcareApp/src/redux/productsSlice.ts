import {
  createSlice,
  type PayloadAction,
} from "@reduxjs/toolkit";
import type { Product } from "../model/ProductModel";

type ProductState = {
  products: Product[];
  query: string;
  sort: string;
};

const initialState: ProductState = {
  products: [],
  query: "",
  sort: "az",
};

const productsSlice = createSlice({
  name: "products",
  initialState,
  reducers: {
    setQuery: (state, action) => {
      state.query = action.payload;
    },
    setProductsRedux: (
      state,
      action: PayloadAction<Product[]>
    ) => {
      state.products = action.payload;
    },
    sortBy: (state, action) => {
      state.sort = action.payload;
    },
  },
});

export default productsSlice.reducer;
export const {
  setQuery,
  setProductsRedux,
  sortBy,
} = productsSlice.actions;
