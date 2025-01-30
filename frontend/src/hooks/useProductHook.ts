import { useCallback, useEffect, useState } from "react";
import { getFilteredProducts, getProducts } from "../services/productServices";
import { useCookies } from "react-cookie";
import { IGenericProduct } from "../types/IGenericProduct";
import { useNavigate } from "react-router-dom";

export const useProductHook = () => {
  const [cookies] = useCookies(["token"]);
  const [products, setProducts] = useState<IGenericProduct[]>();
  const navigate = useNavigate();

  useEffect(() => {
    if (cookies.token) {
      getProducts(cookies.token).then((result) => {
        setProducts(result);
      });
    }
  }, [cookies.token]);

  const searchProductsByString = useCallback(
    (string: string) => {
      getFilteredProducts(cookies.token, string).then((result) =>
        setProducts(result),
      );
    },
    [cookies.token],
  );

  const getDetailedView = (id: number) => {
    navigate(`/products/${id}`);
  };

  return { products, searchProductsByString, getDetailedView };
};
