# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

1Remote is a modern personal remote session manager and launcher built with WPF and .NET. It supports multiple remote protocols (RDP, SSH, VNC, Telnet, FTP, SFTP, Serial) and provides a unified interface for managing remote connections.

## Build Commands

### Visual Studio
1. Open `1Remote.sln` in Visual Studio 2022
2. Restore NuGet packages
3. Build solution (Ctrl+Shift+B)

### Command Line (PowerShell)
The project uses Invoke-Build for automated builds:

```powershell
# Set alias for convenience (run in repository root)
Set-Alias ib $pwd\Invoke-Build.ps1

# List available tasks
ib ?

# Clean and build release version
ib Clean, Build -aReleaseType Release

# Install dependencies and build
ib Deps, Build

# Build in Windows Sandbox (pristine environment)
ib BuildInSandbox
```

### Build Configurations
- `Debug` - Development build with console window
- `Release` - Release build (WinExe)
- `StoreDebug` / `StoreRelease` - Microsoft Store builds
- `ReleaseNet48` - .NET Framework 4.8 build
- `ReleaseNet6` - .NET 6.0 build
- Default targeting is `net9.0-windows10.0.19041.0`

## Architecture

### Core Patterns
- **MVVM** with Stylet framework for UI architecture
- **Dependency Injection** using StyletIoC container
- **Service Layer** pattern with singleton services
- **Protocol Abstraction** with polymorphic implementations
- **Repository Pattern** for data access

### Key Directories

**`Ui/` (Main Project):**
- `Model/Protocol/` - Protocol implementations (RDP, SSH, VNC, Telnet, FTP, SFTP, Serial)
- `Model/ProtocolRunner/` - Protocol execution engines (internal/external runners)
- `View/` - XAML views and ViewModels
  - `Editor/` - Server configuration forms
  - `Host/` - Protocol hosting controls
  - `Settings/` - Configuration pages
- `Service/` - Business logic services (Configuration, DataSource, SessionControl)
- `Utils/` - Utility classes (PuTTY integration, Windows API wrappers)

**Supporting Projects:**
- `Shawn.Utils` - Core utilities and interfaces
- `Shawn.Utils.Wpf` - WPF-specific utilities and MVVM framework
- `VncSharpCore` - VNC protocol implementation
- `Dragablz` - Tabbed window management

### Protocol Architecture

**Protocol Hierarchy:**
```
ProtocolBase (abstract)
├── ProtocolBaseWithAddressPortUserPwd
│   ├── RDP, SSH, VNC, Telnet, FTP, SFTP, LocalApp
└── Serial
```

**Runner System:**
- `InternalDefaultRunner` - Built-in protocol execution
- `InternalExeRunner` - External executable integration (PuTTY, Kitty)
- `ExternalRunner` - Generic external process runners

### Data Management
- **Primary Storage**: SQLite database
- **Configuration**: JSON files with versioning
- **Import**: mRemoteNG compatibility
- **Deployment Modes**: Portable (app directory) or AppData (user profile)

### Key Services
- `ConfigurationService` - Application configuration and preferences
- `DataSourceService` - Multi-source data management
- `SessionControlService` - Active remote session management
- `ProtocolConfigurationService` - Protocol-specific settings
- `LanguageService` - Internationalization (Chinese/English)
- `ThemeService` - UI theming system

## Development Notes

### Entry Points
- `App.xaml` - Application startup with Stylet integration
- `Bootstrapper.cs` - DI container setup and service initialization
- `AppInit.cs` - Multi-stage application initialization

### Adding New Protocols
1. Inherit from appropriate base class (`ProtocolBase` or `ProtocolBaseWithAddressPortUserPwd`)
2. Add to `JsonKnownTypes` attribute for serialization
3. Create corresponding View and ViewModel in `View/Editor/Forms/`
4. Register in protocol configuration system

### Testing
- No comprehensive test suite currently present
- DI container enables easy unit testing setup
- Mock-friendly architecture with interface-based design

### Configuration System
- JSON-based configuration with automatic versioning
- Settings stored in `%APPDATA%\1Remote` (AppData mode) or app directory (Portable mode)
- Protocol-specific configuration classes with inheritance
- Credential encryption and secure storage

### External Dependencies
- RDP: Windows MSTSC (MSTSCLib.dll, AxMSTSCLib.dll)
- SSH: SSH.NET library or external PuTTY/KiTTY
- VNC: Custom VncSharpCore implementation
- FTP/SFTP: FluentFTP library
- Database: System.Data.SQLite.Core (supports MySQL, PostgreSQL, SQLite)

### UI Framework
- Stylet for MVVM framework and DI container
- Dragablz for tabbed interface
- MahApps.Metro-style theming system
- Custom controls for protocol-specific needs

### Security Considerations
- Credential encryption using custom salt
- Secure credential storage and transmission
- Integration with Windows credential manager (optional)
- Audit logging for connection activities