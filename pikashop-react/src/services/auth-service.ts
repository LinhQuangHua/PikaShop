import { User, UserManager, UserManagerSettings } from "oidc-client";
import { hostURL, authURL } from "../config";

const oidcSettings: UserManagerSettings = {
  authority: hostURL,
  client_id: "react_code_client",
  redirect_uri: `${authURL}/authentication/login-callback`,
  post_logout_redirect_uri: `${authURL}/authentication/logout-callback`,
  response_type: "code",
  scope: "pikashop.api openid profile",
  automaticSilentRenew: true,
  includeIdTokenInSilentRenew: true,
};

class AuthService {

  public userManager: UserManager;

  constructor() {
    this.userManager = new UserManager(oidcSettings);
  }

  public getUserAsync(): Promise<User | null> {
    return this.userManager.getUser();
  }

  public loginAsync(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  public completeLoginAsync(url: string): Promise<User> {
    return this.userManager.signinCallback(url);
  }

  public renewTokenAsync(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public logoutAsync(): Promise<void> {
    return this.userManager.signoutRedirect();
  }

  public async completeLogoutAsync(url: string): Promise<void> {
    await this.userManager.signoutCallback(url);
  }
}

export default new AuthService();
