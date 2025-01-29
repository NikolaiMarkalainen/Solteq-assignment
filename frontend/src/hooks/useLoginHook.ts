import { useState, useCallback } from "react";
import { logUserIn, registerUser } from "../services/loginServices";
import { useCookies } from "react-cookie";
import { useNavigate } from "react-router-dom";

export const useLoginHook = () => {
  const [password, setPassword] = useState<string>();
  const [username, setUsername] = useState<string>();
  const [verificationPassword, setVerificationPassword] = useState<string>();
  const [errorMessage, setErrorMessage] = useState<string>();
  const [, setCookie] = useCookies(["token"]);

  const navigate = useNavigate();

  const handleUserNameChange = useCallback((text: string) => {
    console.log(text);
    setUsername(text);
  }, []);

  const handlePasswordChange = useCallback((text: string) => {
    console.log(text);
    setPassword(text);
  }, []);

  const handlePasswordVerification = useCallback((text: string) => {
    console.log(text);
    setVerificationPassword(text);
  }, []);

  const genericFieldVerification = (): boolean => {
    if (!username && !password) {
      setErrorMessage("Fill in the credentials to continue");
      return false;
    }
    if (!username) {
      setErrorMessage("Username is not filled");
      return false;
    }
    if (!password) {
      setErrorMessage("Password is not filled");
      return false;
    }
    return true;
  };

  const verifyPasswordIntegrity = async () => {
    if (password !== verificationPassword) {
      setErrorMessage("Passwords do not match");
      return;
    }
    if (password && password.length < 5) {
      setErrorMessage("Password length is under 5 characters");
      return;
    }
    const validInput = genericFieldVerification();

    if (validInput) {
      const requestBody = {
        username: username!,
        password: password!,
      };

      const result = registerUser(requestBody);
      console.log(result);
      navigate("/login");
    }
  };

  const handleInputFocus = () => {
    setErrorMessage("");
  };

  const onSubmit = async (isRegistering: boolean) => {
    if (isRegistering) verifyPasswordIntegrity();
    const validInput = genericFieldVerification();

    if (validInput) {
      const requestBody = {
        username: username!,
        password: password!,
      };
      await logUserIn(requestBody).then((result) => {
        setCookie("token", result.token, {
          path: "/",
          expires: new Date(Date.now() + 3600 * 1000),
        });
      });
      navigate("/home");
    }
  };

  return {
    handleUserNameChange,
    handlePasswordChange,
    handlePasswordVerification,
    onSubmit,
    errorMessage,
    handleInputFocus,
  };
};
