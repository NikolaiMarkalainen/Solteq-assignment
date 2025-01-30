import { useCookies } from "react-cookie";
import { Header } from "./Header";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getSingleProductDetails } from "../services/productServices";
import { IProduct } from "../types/IProduct";
import "./singleproduct.css";

export const SingleProductView = () => {
  const [cookie] = useCookies(["token"]);
  const params = useParams();
  const [product, setProduct] = useState<IProduct>();
  const apiUrl = import.meta.env.VITE_API_URL;

  useEffect(() => {
    if (params.id && cookie.token) {
      console.log(params.id);
      getSingleProductDetails(cookie.token, params.id).then((result) =>
        setProduct(result),
      );
    }
  }, [cookie.token, params.id]);

  return (
    <div>
      <Header />
      {product && (
        <div className="singleproduct-container">
          <h1 className="singleproduct-header">{product?.productName}</h1>
          <div className="singleproduct-body">
            <div className="singleproduct-image-parent">
              <div className="singleproduct-image-description">
                {product?.customText}
              </div>

              <img
                className="singleproduct-image"
                src={`${apiUrl}/api/Products/image/${product?.id}`}
              />
              <div className="singleproduct-image-text">
                <div style={{ display: "flex", flexDirection: "row" }}>
                  <p> EAN Koodi:</p>
                  <p style={{ fontWeight: "bold" }}>{product?.id}</p>
                </div>
                <div style={{ display: "flex", flexDirection: "row" }}>
                  <p> Paino:</p>
                  <p style={{ fontWeight: "bold" }}>{product?.weight}</p>
                </div>
              </div>
              <div className="singleproduct-warning">{product?.warning}</div>
            </div>
            <div className="secondhalf-product">
              <div className="singleproduct-contains-parent">
                <div className="singleproduct-contains">
                  <p>Tuote sisältää</p>
                  {product.productContains.map((item, index) => (
                    <ul className="singleproduct-list">
                      <li key={index}>{item}</li>
                    </ul>
                  ))}
                </div>
                <div className="singleproduct-contains">
                  <p>Tuote ei sisällä</p>
                  {product.productDoesNotContain.map((item, index) => (
                    <ul className="singleproduct-list">
                      <li key={index}>{item}</li>
                    </ul>
                  ))}
                </div>
              </div>
              <div className="singleproduct-nutrition-container">
                <div className="single-product-nutrition-parent">
                  <h3>Ravintosisältö 100g:ssa</h3>
                  <div className="nutrition-list">
                    <p className="nutrition-list-key">Energia:</p>
                    <p className="nutrition-list-value">
                      {product.nutritionalDetails.calories}
                    </p>
                  </div>
                  <div className="nutrition-list">
                    <p className="nutrition-list-key">Rasva</p>
                    <p className="nutrition-list-value">
                      {product.nutritionalDetails.fat}
                    </p>
                  </div>
                  <div className="nutrition-list">
                    <p className="nutrition-list-child-key">
                      josta tyydyttynyttä
                    </p>
                    <p className="nutrition-list-value">
                      {product.nutritionalDetails.saturatedFat}
                    </p>
                  </div>
                  <div className="nutrition-list">
                    <p className="nutrition-list-key">Hiilihydraatit</p>
                    <p className="nutrition-list-value">
                      {product.nutritionalDetails.carbohydrates}
                    </p>
                  </div>
                  <div className="nutrition-list">
                    <p className="nutrition-list-child-key">josta sokeria</p>
                    <p className="nutrition-list-value">
                      {product.nutritionalDetails.sugars}
                    </p>
                  </div>
                  <div className="nutrition-list">
                    <p className="nutrition-list-child-key">josta polyoleja</p>
                    <p className="nutrition-list-value">
                      {product.nutritionalDetails.polyols}
                    </p>
                  </div>
                  <div className="nutrition-list">
                    <p className="nutrition-list-key">Proteiini</p>
                    <p className="nutrition-list-value">
                      {product.nutritionalDetails.protein}
                    </p>
                  </div>
                  <div className="nutrition-list">
                    <p className="nutrition-list-key">Suola</p>
                    <p className="nutrition-list-value">
                      {product.nutritionalDetails.salt}
                    </p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};
