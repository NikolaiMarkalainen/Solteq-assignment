import { useNavigate } from "react-router-dom";
import "./LoginCard.css";

interface props {
  header: string;
  primaryButtonText: string;
  secondaryButtonText?: string;
  verifyPassword?: boolean;
  registerCheck: string;
  onChangeUsername: (text: string) => void;
  onChangePassword: (text: string) => void;
  onVerificationPassword?: (text: string) => void;
  onSubmit: (register: boolean) => void;
  errorMessage?: string;
  handleInputFocus: () => void;
}

export const LoginCard = (props: props) => {
  const navigate = useNavigate();
  const changePage = (e: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
    e.preventDefault();
    navigate(props.verifyPassword ? "/login" : "/register");
  };

  return (
    <div className="login-form-parent">
      <div className="login-form">
        <h1 className="login-form-header">{props.header}</h1>
        <div> Käyttäjäntunnus</div>
        <input
          type="text"
          className="input-field"
          onFocus={props.handleInputFocus}
          onChange={(e) => props.onChangeUsername(e.target.value)}></input>
        <div> Salasana</div>
        <input
          type="password"
          className="input-field"
          onFocus={props.handleInputFocus}
          onChange={(e) => props.onChangePassword(e.target.value)}></input>
        {props.verifyPassword && props.onVerificationPassword && (
          <>
            <div> Salasana uudelleen</div>
            <input
              type="password"
              className="input-field"
              onFocus={props.handleInputFocus}
              onChange={(e) =>
                props.onVerificationPassword?.(e.target.value)
              }></input>
          </>
        )}
        {props.errorMessage && (
          <div className="error-message">{props.errorMessage}</div>
        )}
        <div className="login-buttons">
          <a className="link" onClick={(e) => changePage(e)}>
            {props.registerCheck}
          </a>
          <button
            className="primary-action-button"
            style={{ height: "5vh" }}
            onClick={() => props.onSubmit(props.verifyPassword ? true : false)}>
            {props.primaryButtonText}
          </button>
        </div>
      </div>
    </div>
  );
};
