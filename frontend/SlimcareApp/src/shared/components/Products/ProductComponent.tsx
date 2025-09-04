import { Card } from "react-bootstrap";
import type { Product } from "../../../model/ProductModel";
import { useState } from "react";

export default function ProductComponent({
  id,
  img,
  name,
  description,
  price,
}: Product) {
  const [isHovered, setIsHovered] =
    useState(false);
  return (
    <Card
      data-id={id}
      style={{
        width: "20rem",
        transition:
          "transform 0.3s ease, box-shadow 0.3s ease",
        transform: isHovered
          ? "translateY(-8px)"
          : "translateY(0)",
        boxShadow: isHovered
          ? "0 8px 20px rgba(0,0,0,0.2)"
          : "0 2px 6px rgba(0,0,0,0.1)",
        margin: "0 auto",
      }}
      onMouseEnter={() => setIsHovered(true)}
      onMouseLeave={() => setIsHovered(false)}
    >
      <Card.Img
        variant="top"
        src={
          "../../../../public/images/" +
          img +
          ".png"
        }
      ></Card.Img>
      <Card.Body>
        <Card.Title>{name}</Card.Title>
        <Card.Text>{description}</Card.Text>
        <p className="text-end fw-bold">
          {price.toFixed(2)}
        </p>
      </Card.Body>
    </Card>
  );
}
