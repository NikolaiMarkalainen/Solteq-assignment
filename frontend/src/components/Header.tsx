import { useNavigate } from "react-router-dom";
import { useLogoutHook } from "../hooks/useLogoutHook";
import "./mainpage.css";
export const Header = () => {
  const { logout } = useLogoutHook();
  const navigate = useNavigate();
  return (
    <div className="header-container">
      <h1 onClick={() => navigate("/")}>Läkeröl Tuotteet</h1>
      <div className="dropdown-parent">
        <div className="header-menu-parent">
          <div className="header-menu-button"></div>
          <div className="header-menu-button"></div>
          <div className="header-menu-button"></div>
          <div className="dropdown-menu-item">
            <p onClick={() => logout()}>Kirjaudu ulos</p>
          </div>
        </div>
      </div>
    </div>
  );
};
