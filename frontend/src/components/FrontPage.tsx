import { useProductHook } from "../hooks/useProductHook";
import { Header } from "./Header";
import "./mainpage.css";
import { ProductCard } from "./shared/ProductCard";
import { SearchInput } from "./shared/SearchInput";

export const FrontPage = () => {
  const { products, searchProductsByString, filteredProducts } =
    useProductHook();
  console.log(products);
  return (
    <div className="main-container">
      <Header />
      <SearchInput
        products={filteredProducts}
        onSearchProduct={searchProductsByString}
      />
      {products && (
        <div className="product-container">
          <ProductCard id={products[0].id} />
          <ProductCard id={products[1].id} />
          <ProductCard id={products[2].id} />
          <ProductCard id={products[3].id} />
          <ProductCard id={products[4].id} />
          <ProductCard id={products[5].id} />
          <ProductCard id={products[6].id} />
          <ProductCard id={products[7].id} />
        </div>
      )}
    </div>
  );
};
