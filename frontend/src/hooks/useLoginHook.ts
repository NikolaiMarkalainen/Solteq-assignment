import { useState, useCallback } from "react";
import { logUserIn, registerUser } from "../services/loginServices";
export const useLoginHook = () => {
  const [password, setPassword] = useState<string>();
  const [username, setUsername] = useState<string>();
  const [verificationPassword, setVerificationPassword] = useState<string>();
  const [errorMessage, setErrorMessage] = useState<string>();

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
    }
  };

  const handleInputFocus = () => {
    setErrorMessage("");
  };

  const onSubmit = (isRegistering: boolean) => {
    if (isRegistering) verifyPasswordIntegrity();
    const validInput = genericFieldVerification();

    if (validInput) {
      const requestBody = {
        username: username!,
        password: password!,
      };
      const result = logUserIn(requestBody);
      console.log(result);
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
