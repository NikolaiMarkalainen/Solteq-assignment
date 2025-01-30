import "./ProductCard.css";
import React from "react";
interface props {
  id: number;
  productName: string;
  category: string;
  onProductClick: (id: number) => void;
}
export const ProductCard = React.memo((props: props) => {
  return (
    <div
      className="product-card-main"
      onClick={() => props.onProductClick(props.id)}>
      <div className="product-card-header">{props.productName}</div>
      <div className="product-card-category">{props.category}</div>
      <img
        src={`http://localhost:5151/api/Products/image/${props.id}`}
        className="product-card-image"
        alt="Image"
      />
      <div></div>
    </div>
  );
});
