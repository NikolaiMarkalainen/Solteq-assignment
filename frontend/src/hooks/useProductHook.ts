import { useEffect, useState } from "react";
import { getFilteredProducts, getProducts } from "../services/productServices";
import { useCookies } from "react-cookie";
import { IGenericProduct } from "../types/IGenericProduct";

export const useProductHook = () => {
  const [cookies] = useCookies(["token"]);
  const [products, setProducts] = useState<IGenericProduct[]>();

  useEffect(() => {
    getProducts(cookies.token).then((result) => {
      setProducts(result);
    });
  }, [cookies.token]);

  const searchProductsByString = (string: string) => {
    if (products) {
      getFilteredProducts(cookies.token, string).then((result) =>
        setProducts(result),
      );
    } else {
      return;
    }
  };

  return { products, searchProductsByString };
};
