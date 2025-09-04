import { Select } from "antd";
import { useDispatch } from "react-redux";
import { sortBy } from "../../../redux/productsSlice";

export default function Sort() {
  const dispatch = useDispatch();
  function handleSort(input: string) {
    dispatch(sortBy(input));
  }
  return (
    <div
      className="mb-3 mt-3 text-center border-bottom"
      style={{ fontSize: "18px" }}
    >
      <Select
        style={{
          width: "80%",
          marginBottom: "15px",
        }}
        options={[
          {
            value: "az",
            label: <span>A - Z</span>,
          },
          {
            value: "za",
            label: <span>Z - A</span>,
          },
          {
            value: "price",
            label: <span>Price</span>,
          },
        ]}
        defaultValue={"az"}
        onSelect={(e) => handleSort(e)}
      />
      <p
        style={{
          fontSize: "12px",
          color: "grey",
        }}
        className="fst-italic"
      >
        92 products
      </p>
    </div>
  );
}
