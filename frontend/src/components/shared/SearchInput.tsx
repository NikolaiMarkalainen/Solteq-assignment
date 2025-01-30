import { IGenericProduct } from "../../types/IGenericProduct";
import "./SearchInput.css";

interface props {
  products?: IGenericProduct[];
  onSearchProduct: (k: string) => void;
}

export const SearchInput = (props: props) => {
  return (
    <div className="search-parent">
      <p>Etsi tuote nimellä tai koodilla</p>
      <div className="search-field">
        <img src="./icons8-search-480.svg" />
        <input
          className="search-input"
          onChange={(e) => props.onSearchProduct(e.target.value)}></input>
      </div>
    </div>
  );
};
