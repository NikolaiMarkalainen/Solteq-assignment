import { useProductHook } from "../hooks/useProductHook";
import { Header } from "./Header";
import "./mainpage.css";
import { ProductCard } from "./shared/ProductCard";
import { SearchInput } from "./shared/SearchInput";

export const FrontPage = () => {
  const { products, searchProductsByString } = useProductHook();
  return (
    <div className="main-container">
      <Header />
      <SearchInput onSearchProduct={searchProductsByString} />
      {products && (
        <div className="product-container">
          {products.map((m) => (
            <ProductCard
              key={m.id}
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
