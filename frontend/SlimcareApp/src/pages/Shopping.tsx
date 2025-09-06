import React from "react";
import type { MenuProps } from "antd";
import {
  Breadcrumb,
  Layout,
  Menu,
  theme,
} from "antd";
import Search from "../shared/components/Shopping/Search";
import Sort from "../shared/components/Shopping/Sort";
import Products from "../shared/components/Shopping/Products";

const { Content, Sider } = Layout;

const items: MenuProps["items"] = [
  "Beauty",
  "Equipment",
  "Weight",
  "Clothes",
].map((i, index) => {
  const key = String(index + 1);
  return {
    key: `sub${key}`,
    label: `${i}`,
    children: Array.from({ length: 3 }).map(
      (_, j) => {
        const subKey = index * 4 + j + 1;
        return {
          key: subKey,
          label: `option ${subKey}`,
        };
      }
    ),
  };
});

const App: React.FC = () => {
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  return (
    <Layout>
      <Layout>
        <Sider
          width={250}
          style={{ background: colorBgContainer }}
          breakpoint="md"
          collapsedWidth={0}
        >
          <Search></Search>
          <Sort></Sort>
          <Menu
            mode="inline"
            style={{
              height: "100%",
              borderInlineEnd: 0,
              fontSize: "18px",
            }}
            items={items}
          />
        </Sider>
        <Layout
          style={{ padding: "0 24px 24px" }}
        >
          <Breadcrumb
            items={[
              { title: "Home" },
              { title: "Products" },
            ]}
            style={{
              margin: "16px 0",
              fontSize: "20px",
            }}
          />
          <Content
            style={{
              padding: 24,
              margin: 0,
              minHeight: 280,
              background: colorBgContainer,
              borderRadius: borderRadiusLG,
            }}
          >
            <Products></Products>
          </Content>
        </Layout>
      </Layout>
    </Layout>
  );
};

export default App;
