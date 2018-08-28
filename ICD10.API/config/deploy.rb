# config valid for current version and patch releases of Capistrano
lock "~> 3.11.0"

set :application, "elite-icd-10-api"
set :repo_url, "https://github.com/EliteSoftwareEU/EliteICD10.API.NET"
set :branch, "master"
set :deploy_to, "/home/deployer/apps"
set :format_options, command_output: true, log_file: "log/capistrano.log", color: :auto, truncate: :auto
#append :linked_files, "appsettings.json"

# Default value for linked_dirs is []
# append :linked_dirs, "log", "tmp/pids", "tmp/cache", "tmp/sockets", "public/system"

# Default value for default_env is {}
# set :default_env, { path: "/opt/ruby/bin:$PATH" }

# Default value for local_user is ENV['USER']
# set :local_user, -> { `git config user.name`.chomp }

# Default value for keep_releases is 5
set :keep_releases, 5
# set :ssh_options, verify_host_key: :secure
