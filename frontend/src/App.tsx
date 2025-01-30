import { Navigate, Route, Routes } from "react-router-dom";
import { Login } from "./components/Login";
import { Register } from "./components/Register";
import { useCookies } from "react-cookie";
import { FrontPage } from "./components/FrontPage";
import { ProtectedRoute } from "./ProtectedRoute";
import { SingleProductView } from "./components/SingleProductView";
import { RouteEnum } from "./types/RouteEnum";

export const App = () => {
  const [cookie] = useCookies(["token"]);

  return (
    <Routes>
      <Route path={RouteEnum.Login} element={<Login />} />
      <Route path={RouteEnum.Register} element={<Register />} />
      <Route element={<ProtectedRoute isAuthenticated={!!cookie.token} />}>
        <Route path="*" element={<Navigate to={RouteEnum.Main} replace />} />

        <Route path={RouteEnum.Main} element={<FrontPage />} />
        <Route path={RouteEnum.SingleProduct} element={<SingleProductView />} />
      </Route>
    </Routes>
  );
};
