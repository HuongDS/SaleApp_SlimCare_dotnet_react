import { api } from "../api/api";

import type {
  PageResult,
  Product,
} from "../model/ProductModel";


export async function getProductsWithQuantity(
  quantity: number
) {
  const products = await api.get<Product[]>(
    `/GetProductWithQuantity/${quantity}`
  );
  return products.data;
}

export async function getProductsWithPagination({
  pageIndex,
  pageSize,
}: {
  pageIndex: number;
  pageSize: number;
}) {
  const res = await api.get<PageResult>(
    `/GetProducts/${pageIndex}/${pageSize}`
  );
  return res.data;
}

