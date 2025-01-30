import "./ProductCard.css";

interface props {
  id: number;
  productName: string;
  category: string;
}
export const ProductCard = (props: props) => {
  console.log("req");
  return (
    <div className="product-card-main">
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
};
