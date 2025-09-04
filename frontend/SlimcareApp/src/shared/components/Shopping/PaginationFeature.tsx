import { Pagination } from "antd";

export default function PaginationFeature({
  page,
  totalCount,
  onChange,
}: {
  page: number;
  totalCount: number;
  onChange: (p: number) => void;
}) {
  return (
    <Pagination
      align="center"
      current={page}
      total={totalCount}
      pageSize={12}
      onChange={onChange}
    ></Pagination>
  );
}
