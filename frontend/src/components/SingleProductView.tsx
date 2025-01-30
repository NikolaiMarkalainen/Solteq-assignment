import { useCookies } from "react-cookie";
import { Header } from "./Header";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getSingleProductDetails } from "../services/productServices";
import { IProduct } from "../types/IProduct";

export const SingleProductView = () => {
  const [cookie] = useCookies(["token"]);
  const params = useParams();
  const [product, setProduct] = useState<IProduct>();
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
      <></>
    </div>
  );
};
