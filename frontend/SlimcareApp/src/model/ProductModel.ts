export type Product = {
  id: number;
  img: string;
  name: string;
  description: string;
  price: number;
  stock: number;
};

export type PageResult = {
  items: Product[];
  totalCount: number;
  pageSize: number;
  currentpage: number;
  totalPages: number;
};
