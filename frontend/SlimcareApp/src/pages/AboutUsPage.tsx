import React from "react";
import {
  Breadcrumb,
  Card,
  Divider,
  Layout,
  theme,
} from "antd";
import HeroSection from "../shared/components/AboutUsPage/HeroSection";
import MissionAndVision from "../shared/components/AboutUsPage/MissionAndVision";
import Story from "../shared/components/AboutUsPage/Story";
import CTA from "../shared/components/AboutUsPage/CTA";

const { Content } = Layout;

const AboutUsPage: React.FC = () => {
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  return (
    <Layout>
      <Content style={{ padding: "0 48px" }}>
        <Breadcrumb
          style={{ margin: "16px 0" }}
          items={[
            { title: "Home" },
            { title: "About Us" },
          ]}
        />
        <div
          style={{
            background: colorBgContainer,
            minHeight: 280,
            padding: 24,
            borderRadius: borderRadiusLG,
          }}
        >
          <Card>
            <HeroSection />
            <Divider />
            <MissionAndVision />
            <Divider />
            <Story />
            <Divider />
            <CTA />
          </Card>
        </div>
      </Content>
    </Layout>
  );
};

export default AboutUsPage;
