import { Col, InputNumber, Tooltip } from "antd";
import { useState } from "react";

export default function Quantity({
  stock,
}: {
  stock: number;
}) {
  const [value, setValue] = useState(1);
  return (
    <Col xs={24} sm={12}>
      <Tooltip title={`Tối đa ${stock} sản phẩm`}>
        <InputNumber
          addonBefore="Số lượng"
          min={1}
          max={stock}
          value={value}
          style={{ width: "100%" }}
          onChange={(e) => setValue(e ? e : 1)}
        />
      </Tooltip>
    </Col>
  );
}
