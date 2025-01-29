import { useEffect, useState } from "react";
import { useCookies } from "react-cookie";
import { getProducts } from "../services/productServices";
import { Header } from "./Header";
import "./mainpage.css";

export const FrontPage = () => {
  const [cookies] = useCookies(["token"]);
  const [products, setProducts] = useState<any>();
  useEffect(() => {
    const result = getProducts(cookies.token);
    setProducts(result);
  }, [cookies.token]);

  console.log(products);
  return (
    <div className="main-container">
      <Header />
      <div></div>
    </div>
  );
};
