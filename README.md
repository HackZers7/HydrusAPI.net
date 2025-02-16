# HydrusAPI.net

⚠️ **Warning: This is an Early Development Version!** ⚠️

Some features may not be fully implemented yet.

The latest supported version of Hydrus API: 78 (607)

## Supports:

### Access Management

| URL                      | Status | Request builder | Structured type |
|--------------------------|:------:|:---------------:|:---------------:|
| /api_version             |   ✅    |        ❌        |        ❌        |
| /request_new_permissions |   ✅    |        ❌        |        ❌        |
| /session_key             |   ✅    |        ❌        |        ❌        |
| /verify_access_key       |   ✅    |        ❌        |        ❌        |
| /get_service             |   ✅    |        ❌        |        ❌        |
| /get_services            |   ✅    |        ❌        |        ❌        |

### Importing and Deleting Files

| URL                                   | Status | Request builder | Structured type |
|---------------------------------------|:------:|:---------------:|:---------------:|
| /add_files/add_file                   |   ✅    |        ❌        |        ❌        |
| /add_files/delete_files               |   ✅    |        ❌        |   Not needed    |
| /add_files/undelete_files             |   ✅    |        ❌        |   Not needed    |
| /add_files/clear_file_deletion_record |   ✅    |        ❌        |   Not needed    |
| /add_files/migrate_files              |   ✅    |        ❌        |   Not needed    |
| /add_files/archive_files              |   ✅    |        ❌        |   Not needed    |
| /add_files/unarchive_files            |   ✅    |        ❌        |   Not needed    |
| /add_files/generate_hashes            |   ✅    |        ❌        |        ❌        |

### Importing and Editing URLs

| URL                     | Status | Request builder | Structured type |
|-------------------------|:------:|:---------------:|:---------------:|
| /add_urls/get_url_files |   ✅    |        ❌        |        ❌        |
| /add_urls/get_url_info  |   ✅    |        ❌        |        ❌        |
| /add_urls/add_url       |   ✅    |        ❌        |        ❌        |
| /add_urls/associate_url |   ✅    |        ❌        |   Not needed    |

### Editing File Tags

| URL                                | Status | Request builder | Structured type |
|------------------------------------|:------:|:---------------:|:---------------:|
| /add_tags/clean_tags               |   ✅    |        ❌        |        ❌        |
| /add_tags/get_siblings_and_parents |   ✅    |        ❌        |        ❌        |
| /add_tags/search_tags              |   ✅    |        ❌        |        ❌        |
| /add_tags/add_tags                 |   ✅    |        ❌        |   Not needed    |

### Editing File Ratings

| URL                      | Status | Request builder | Structured type |
|--------------------------|:------:|:---------------:|:---------------:|
| /edit_ratings/set_rating |   ✅    |        ❌        |   Not needed    |

### Editing File Times

| URL                                 | Status | Request builder | Structured type |
|-------------------------------------|:------:|:---------------:|:---------------:|
| /edit_times/increment_file_viewtime |   ✅    |        ❌        |   Not needed    |
| /edit_times/set_file_viewtime       |   ✅    |        ❌        |   Not needed    |
| /edit_times/set_time                |   ✅    |        ❌        |   Not needed    |

### Editing File Notes

| URL                     | Status | Request builder | Structured type |
|-------------------------|:------:|:---------------:|:---------------:|
| /add_notes/set_notes    |   ✅    |        ❌        |        ❌        |
| /add_notes/delete_notes |   ✅    |        ❌        |   Not needed    |

### Searching and Fetching Files

| URL                                     | Status | Request builder | Structured type |
|-----------------------------------------|:------:|:---------------:|:---------------:|
| /get_files/search_files                 |   ✅    |        ❌        |        ❌        |
| /get_files/file_hashes                  |   ✅    |        ❌        |        ❌        |
| /get_files/file_metadata                |   ✅    |        ❌        |        ❌        |
| /get_files/file                         |   ✅    |        ❌        |   Not needed    |
| /get_files/thumbnail                    |   ✅    |        ❌        |   Not needed    |
| /get_files/file_path                    |   ✅    |        ❌        |        ❌        |
| /get_files/thumbnail_path               |   ✅    |        ❌        |        ❌        |
| /get_files/local_file_storage_locations |   ✅    |        ❌        |        ❌        |
| /get_files/render                       |   ✅    |        ❌        |   Not needed    |

### Managing File Relationships

| URL                                               | Status | Request builder | Structured type |
|---------------------------------------------------|:------:|:---------------:|:---------------:|
| /manage_file_relationships/get_file_relationships |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/get_potentials_count   |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/get_potential_pairs    |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/get_random_potentials  |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/remove_potentials      |   ✅    |        ❌        |   Not needed    |
| /manage_file_relationships/set_file_relationships |   ✅    |        ❌        |   Not needed    |
| /manage_file_relationships/set_kings              |   ✅    |        ❌        |   Not needed    |

### Managing Services

| URL                                 | Status | Request builder | Structured type |
|-------------------------------------|:------:|:---------------:|:---------------:|
| /manage_services/get_pending_counts |   ✅    |        ❌        |        ❌        |
| /manage_services/commit_pending     |   ✅    |        ❌        |   Not needed    |
| /manage_services/forget_pending     |   ✅    |        ❌        |   Not needed    |

### Managing Cookies

| URL                         | Status | Request builder | Structured type |
|-----------------------------|:------:|:---------------:|:---------------:|
| /manage_cookies/get_cookies |   ❌    |        ❌        |        ❌        |
| /manage_cookies/set_cookies |   ❌    |        ❌        |        ❌        |

### Managing HTTP Headers

| URL                            | Status | Request builder | Structured type |
|--------------------------------|:------:|:---------------:|:---------------:|
| /manage_headers/get_headers    |   ❌    |        ❌        |        ❌        |
| /manage_headers/set_headers    |   ❌    |        ❌        |        ❌        |
| /manage_headers/set_user_agent |   ❌    |        ❌        |        ❌        |

### Managing Pages

| URL                         | Status | Request builder | Structured type |
|-----------------------------|:------:|:---------------:|:---------------:|
| /manage_pages/get_pages     |   ✅    |        ❌        |        ❌        |
| /manage_pages/get_page_info |   ❌    |        ❌        |        ❌        |
| /manage_pages/add_files     |   ✅    |        ❌        |   Not needed    |
| /manage_pages/focus_page    |   ✅    |        ❌        |   Not needed    |
| /manage_pages/refresh_page  |   ✅    |        ❌        |   Not needed    |

### Managing Popups

| URL                                     | Status | Request builder | Structured type |
|-----------------------------------------|:------:|:---------------:|:---------------:|
| /manage_popups/get_popups               |   ❌    |        ❌        |        ❌        |
| /manage_popups/add_popup                |   ❌    |        ❌        |        ❌        |
| /manage_popups/call_user_callable       |   ❌    |        ❌        |   Not needed    |
| /manage_popups/cancel_popup             |   ❌    |        ❌        |   Not needed    |
| /manage_popups/dismiss_popup            |   ❌    |        ❌        |   Not needed    |
| /manage_popups/finish_popup             |   ❌    |        ❌        |   Not needed    |
| /manage_popups/finish_and_dismiss_popup |   ❌    |        ❌        |   Not needed    |
| /manage_popups/update_popup             |   ❌    |        ❌        |        ❌        |

### Managing the Database

| URL                                 | Status | Request builder | Structured type |
|-------------------------------------|:------:|:---------------:|:---------------:|
| /manage_database/force_commit       |   ❌    |        ❌        |   Not needed    |
| /manage_database/lock_on            |   ❌    |        ❌        |   Not needed    |
| /manage_database/lock_off           |   ❌    |        ❌        |   Not needed    |
| /manage_database/mr_bones           |   ❌    |        ❌        |        ❌        |
| /manage_database/get_client_options |   ❌    |        ❌        |        ❌        |

## Future plans:

- Other API request
- Requests builder
- Structured types for response

## Credits

Thanks to [Hydrus Developer](https://github.com/hydrusnetwork/hydrus) for the great app!

It is partially based on concepts and ideas from [SpotifyAPI-NET](https://github.com/JohnnyCrazy/SpotifyAPI-NET), which is licensed under the MIT License.

This project includes code from [octokit.net](https://github.com/octokit/octokit.net), which is licensed under the MIT License.