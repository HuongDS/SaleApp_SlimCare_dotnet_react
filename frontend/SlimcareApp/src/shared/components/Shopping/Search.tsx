import { Input } from "antd";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { setQuery } from "../../../redux/productsSlice";

export default function Search() {
  const { Search } = Input;
  const [value, setValue] = useState("");
  const dispatch = useDispatch();
  return (
    <div
      className="mb-3 mt-3 text-center border-bottom"
      style={{ fontSize: "18px" }}
    >
      <Search
        style={{
          width: "80%",
          marginBottom: "15px",
        }}
        placeholder="Search products..."
        value={value}
        onChange={(e) => {
          setValue(e.target.value);
          dispatch(setQuery(e.target.value));
        }}
      />
    </div>
  );
}
