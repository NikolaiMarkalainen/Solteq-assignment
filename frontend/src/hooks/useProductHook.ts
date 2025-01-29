import { useEffect, useState } from "react";
import { getProducts } from "../services/productServices";
import { useCookies } from "react-cookie";
import { IGenericProduct } from "../types/IGenericProduct";

export const useProductHook = () => {
  const [cookies] = useCookies(["token"]);
  const [products, setProducts] = useState<IGenericProduct[]>();
  const [filteredProducts, setFilteredProducts] = useState<IGenericProduct[]>();

  useEffect(() => {
    getProducts(cookies.token).then((result) => {
      setProducts(result);
    });
  }, [cookies.token]);

  const searchProductsByString = (string: string) => {
    if (products) {
      const filteredProducts = products.filter(
        (product: IGenericProduct) =>
          product.productName.toLowerCase().includes(string.toLowerCase()) ||
          product.id.toString().includes(string),
      );
      setFilteredProducts(filteredProducts);
    } else {
      setFilteredProducts([]);
    }
  };

  return { products, searchProductsByString, filteredProducts };
};
