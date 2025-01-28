export const Login = () => {
  return (
    <div className="login-form-parent">
      <div className="login-form">
        <h1 className="login-form-header">Kirjaudu sisään</h1>
        <div className="input-field-parent">
          <div> Käyttäjäntunnus</div>
          <input className="input-field"></input>
          <div> Salasana</div>
          <input className="input-field"></input>
        </div>
        <div className="login-buttons">
          <button className="primary-action-button">Login</button>
          <button className="alt-action-button">Reset</button>
        </div>
      </div>
    </div>
  );
};
