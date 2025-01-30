import { useCookies } from "react-cookie";

export const useLogoutHook = () => {
  const [, , removeCookie] = useCookies(["token"]);
  const logout = () => {
    removeCookie("token", { path: "/" });
  };
  return { logout };
};
