import { api } from "../api/api";
import type { Product } from "../model/ProductModel";

export async function getProductsWithQuantity(
  quantity: number
) {
  const products = await api.get<Product[]>(
    `/GetProductWithQuantity/${quantity}`
  );
  return products.data;
}
