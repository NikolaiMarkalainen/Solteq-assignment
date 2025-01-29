import { useCookies } from "react-cookie";
import { useNavigate } from "react-router-dom";

export const useLogoutHook = () => {
  const [, , removeCookie] = useCookies(["token"]);
  const navigate = useNavigate();
  const logout = () => {
    removeCookie("token", { path: "/" });
    navigate("/");
  };
  return { logout };
};
