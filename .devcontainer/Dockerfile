# Find the Dockerfile for mcr.microsoft.com/azure-functions/dotnet:3.0-dotnet3-core-tools at this URL
# https://github.com/Azure/azure-functions-docker/blob/master/host/3.0/buster/amd64/dotnet/dotnet-core-tools.Dockerfile
ARG VARIANT="3.1"
FROM mcr.microsoft.com/vscode/devcontainers/dotnetcore:0-${VARIANT}

# Uncomment following lines If you want to enable Development Container Script
# For more details https://github.com/microsoft/vscode-dev-containers/tree/master/script-library

# Avoid warnings by switching to noninteractive
ENV DEBIAN_FRONTEND=noninteractive

# [Option] Install Node.js
ARG INSTALL_NODE="false"
ARG NODE_VERSION="lts/*"
RUN if [ "${INSTALL_NODE}" = "true" ]; then su vscode -c "source /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi

# [Option] Install Azure CLI
ARG INSTALL_AZURE_CLI="false"
COPY scripts/azcli-debian.sh /tmp/scripts/
RUN if [ "$INSTALL_AZURE_CLI" = "true" ]; then bash /tmp/scripts/azcli-debian.sh; fi \
    && apt-get clean -y && rm -rf /var/lib/apt/lists/* /tmp/scripts

# Install new version of git
RUN apt update && apt-get install -y software-properties-common \
    && add-apt-repository -y ppa:git-core/ppa \
    && apt update && apt install git -y

# RUN apt-get update && apt-get upgrade -y && apt-get install -y locales \
#     && localedef -i en_US -c -f UTF-8 -A /usr/share/locale/locale.alias en_US.UTF-8 \
#     && bash -c "$(curl -fsSL https://raw.githubusercontent.com/ohmybash/oh-my-bash/master/tools/install.sh)"
    # apt-get update && curl -ssL https://raw.githubusercontent.com/microsoft/vscode-dev-containers/master/script-library/common-debian.sh -o /tmp/common-script.sh \
    # && /bin/bash /tmp/common-script.sh "$INSTALL_ZSH" "$USERNAME" "$USER_UID" "$USER_GID" \
    # && rm /tmp/common-script.sh
# apt install software-properties-common
# add-apt-repository ppa:git-core/ppa
# apt update; apt install git

# Install PowerShell modules
SHELL ["/usr/bin/pwsh", "-c"]
RUN $ErrorActionPreference='Stop'; \
    Install-Module PSReadLine -Force -AllowPrerelease;

COPY scripts/profile.ps1 /root/.config/powershell/
COPY scripts/codespaces.theme.sh /root/.oh-my-bash/custom/themes/codespaces/
COPY scripts/.bashrc /root/

# Switch back to dialog for any ad-hoc use of apt-get
ENV DEBIAN_FRONTEND=dialog
