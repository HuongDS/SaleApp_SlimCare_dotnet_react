import {
  ReloadOutlined,
  SafetyCertificateOutlined,
  TruckOutlined,
} from "@ant-design/icons";
import {
  Collapse,
  Descriptions,
  Divider,
  Space,
} from "antd";

export default function AddingInform() {
  return (
    <>
      <Descriptions
        style={{ marginTop: 8 }}
        column={1}
        size="small"
        items={[
          {
            key: "ship",
            label: (
              <Space>
                <TruckOutlined />
                Vận chuyển
              </Space>
            ),
            children:
              "Miễn phí đơn từ 500.000đ (nội thành). Giao nhanh 2–4 ngày.",
          },
          {
            key: "return",
            label: (
              <Space>
                <ReloadOutlined />
                Đổi trả
              </Space>
            ),
            children:
              "Đổi trả trong 7 ngày nếu lỗi nhà sản xuất/chưa mở niêm phong.",
          },
          {
            key: "auth",
            label: (
              <Space>
                <SafetyCertificateOutlined />
                Chính hãng
              </Space>
            ),
            children:
              "Sản phẩm có hoá đơn, nguồn gốc rõ ràng.",
          },
        ]}
      />
      <Divider style={{ margin: "12px 0" }} />

      <Collapse
        ghost
        style={{ marginTop: 8 }}
        items={[
          {
            key: "1",
            label: "Cách sử dụng",
            children: (
              <ul
                style={{
                  paddingLeft: 18,
                  margin: 0,
                }}
              >
                <li>
                  Dùng theo hướng dẫn ghi trên bao
                  bì.
                </li>
                <li>
                  Bảo quản nơi khô thoáng, tránh
                  ánh nắng trực tiếp.
                </li>
              </ul>
            ),
          },
          {
            key: "2",
            label: "Lưu ý",
            children: (
              <ul
                style={{
                  paddingLeft: 18,
                  margin: 0,
                }}
              >
                <li>
                  Không dùng cho người mẫn cảm với
                  bất kỳ thành phần nào của sản
                  phẩm.
                </li>
                <li>
                  Ngưng sử dụng nếu có dấu hiệu
                  kích ứng.
                </li>
              </ul>
            ),
          },
        ]}
      />
    </>
  );
}
