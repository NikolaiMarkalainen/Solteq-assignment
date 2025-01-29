import "./ProductCard.css";

interface props {
  id: number;
}
export const ProductCard = (props: props) => {
  return (
    <div className="product-card-main">
      <div className="product-card-header">Läkerol 36g</div>
      <img
        src={`http://localhost:5151/api/Products/image/${props.id}`}
        className="product-card-image"
        alt="Image"
      />
      <div></div>
    </div>
  );
};
