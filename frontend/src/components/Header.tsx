import { useLogoutHook } from "../hooks/useLogoutHook";
import "./mainpage.css";
export const Header = () => {
  const { logout } = useLogoutHook();

  return (
    <div className="header-container">
      <h1>Läkeröl Tuotteet</h1>
      <div className="dropdown-parent">
        <div className="header-menu-parent">
          <div className="header-menu-button"></div>
          <div className="header-menu-button"></div>
          <div className="header-menu-button"></div>
          <div className="dropdown-menu-item">
            <p onClick={() => logout()}>Log out</p>
            <p>asd</p>
          </div>
        </div>
      </div>
    </div>
  );
};
