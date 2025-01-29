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
          {products.map((m) => (
            <ProductCard
              id={m.id}
              productName={m.productName}
              category={m.category}
            />
          ))}
        </div>
      )}
    </div>
  );
};
