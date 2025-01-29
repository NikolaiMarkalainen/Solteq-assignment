import "./LoginCard.css";

interface props {
  header: string;
  primaryButtonText: string;
  secondaryButtonText?: string;
  verifyPassword?: boolean;
  registerCheck: string;
}

export const LoginCard = (props: props) => {
  return (
    <div className="login-form-parent">
      <div className="login-form">
        <h1 className="login-form-header">{props.header}</h1>
        <div> Käyttäjäntunnus</div>
        <input type="text" className="input-field"></input>
        <div> Salasana</div>
        <input type="password" className="input-field"></input>
        {props.verifyPassword && (
          <>
            <div> Salasana uudelleen</div>
            <input type="password" className="input-field"></input>
          </>
        )}
        <div className="login-buttons">
          <a
            className="link"
            href={props.verifyPassword ? `/login` : `/register`}>
            {props.registerCheck}
          </a>
          <button className="primary-action-button" style={{ height: "5vh" }}>
            {props.primaryButtonText}
          </button>
        </div>
      </div>
    </div>
  );
};
