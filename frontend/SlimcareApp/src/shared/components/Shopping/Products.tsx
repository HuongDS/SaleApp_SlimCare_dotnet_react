import { useEffect, useState } from "react";
import type {
  PageResult,
  Product,
} from "../../../model/ProductModel";
import { getProductsWithPagination } from "../../../services/productsService";
import ProductShopComponent from "./ProductShopComponent";
import PaginationFeature from "./PaginationFeature";
import {
  useDispatch,
  useSelector,
} from "react-redux";
import { setProductsRedux } from "../../../redux/productsSlice";
import type { RootState } from "../../../redux/store";

export default function Products() {
  const [products, setProducts] = useState<
    Product[]
  >([]);
  const [data, setData] =
    useState<PageResult | null>(null);
  const [page, setPage] = useState(1);
  const dispatch = useDispatch();
  const query = useSelector(
    (state: RootState) => state.products.query
  );
  const sortBy = useSelector(
    (state: RootState) => state.products.sort
  );
  useEffect(() => {
    (async () => {
      const tmp = await getProductsWithPagination(
        {
          pageIndex: page,
          pageSize: 12,
        }
      );
      const ps = tmp.items.filter((p) =>
        p.name
          .toLocaleLowerCase()
          .includes(query.toLocaleLowerCase())
      );
      switch (sortBy) {
        case "za":
          ps.sort((a, b) =>
            b.name.localeCompare(a.name)
          );
          break;
        case "price":
          ps.sort(
            (p1, p2) => p1.price - p2.price
          );
          break;

        default:
          ps.sort((a, b) =>
            a.name.localeCompare(b.name)
          );
          break;
      }
      setProducts(ps);
      setData(tmp);
      dispatch(setProductsRedux(ps));
    })();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page, query, sortBy]);

  return (
    <div
      style={{
        display: "flex",
        flexWrap: "wrap",
        gap: "20px",
        width: "100%",
        justifyContent: "start",
        margin: "0 auto",
      }}
    >
      {products.map((p) => (
        <ProductShopComponent
          key={p.id}
          id={p.id}
          alt={p.name}
          src={
            "../../../../public/images/" +
            p.img +
            ".png"
          }
          name={p.name}
          price={p.price}
          stock={p.stock}
        ></ProductShopComponent>
      ))}
      <div
        style={{
          width: "100%",
          marginTop: "15px",
        }}
      >
        <PaginationFeature
          page={page}
          totalCount={data ? data.totalCount : 1}
          onChange={(p) => setPage(p)}
        ></PaginationFeature>
      </div>
    </div>
  );
}
