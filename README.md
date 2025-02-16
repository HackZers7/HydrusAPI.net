# HydrusAPI.net

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
| /add_files/delete_files               |   ✅    |        ❌        |        ❌        |
| /add_files/undelete_files             |   ✅    |        ❌        |        ❌        |
| /add_files/clear_file_deletion_record |   ✅    |        ❌        |        ❌        |
| /add_files/migrate_files              |   ✅    |        ❌        |        ❌        |
| /add_files/archive_files              |   ✅    |        ❌        |        ❌        |
| /add_files/unarchive_files            |   ✅    |        ❌        |        ❌        |
| /add_files/generate_hashes            |   ✅    |        ❌        |        ❌        |

### Importing and Editing URLs

| URL                     | Status | Request builder | Structured type |
|-------------------------|:------:|:---------------:|:---------------:|
| /add_urls/get_url_files |   ✅    |        ❌        |        ❌        |
| /add_urls/get_url_info  |   ✅    |        ❌        |        ❌        |
| /add_urls/add_url       |   ✅    |        ❌        |        ❌        |
| /add_urls/associate_url |   ✅    |        ❌        |        ❌        |

### Editing File Tags

| URL                                | Status | Request builder | Structured type |
|------------------------------------|:------:|:---------------:|:---------------:|
| /add_tags/clean_tags               |   ✅    |        ❌        |        ❌        |
| /add_tags/get_siblings_and_parents |   ✅    |        ❌        |        ❌        |
| /add_tags/search_tags              |   ✅    |        ❌        |        ❌        |
| /add_tags/add_tags                 |   ✅    |        ❌        |        ❌        |

### Editing File Ratings

| URL                      | Status | Request builder | Structured type |
|--------------------------|:------:|:---------------:|:---------------:|
| /edit_ratings/set_rating |   ✅    |        ❌        |        ❌        |

### Editing File Times

| URL                                 | Status | Request builder | Structured type |
|-------------------------------------|:------:|:---------------:|:---------------:|
| /edit_times/increment_file_viewtime |   ✅    |        ❌        |        ❌        |
| /edit_times/set_file_viewtime       |   ✅    |        ❌        |        ❌        |
| /edit_times/set_time                |   ✅    |        ❌        |        ❌        |

### Editing File Notes

| URL                     | Status | Request builder | Structured type |
|-------------------------|:------:|:---------------:|:---------------:|
| /add_notes/set_notes    |   ✅    |        ❌        |        ❌        |
| /add_notes/delete_notes |   ✅    |        ❌        |        ❌        |

### Searching and Fetching Files

| URL                                     | Status | Request builder | Structured type |
|-----------------------------------------|:------:|:---------------:|:---------------:|
| /get_files/search_files                 |   ✅    |        ❌        |        ❌        |
| /get_files/file_hashes                  |   ✅    |        ❌        |        ❌        |
| /get_files/file_metadata                |   ✅    |        ❌        |        ❌        |
| /get_files/file                         |   ✅    |        ❌        |        ❌        |
| /get_files/thumbnail                    |   ✅    |        ❌        |        ❌        |
| /get_files/file_path                    |   ✅    |        ❌        |        ❌        |
| /get_files/thumbnail_path               |   ✅    |        ❌        |        ❌        |
| /get_files/local_file_storage_locations |   ✅    |        ❌        |        ❌        |
| /get_files/render                       |   ✅    |        ❌        |        ❌        |

### Managing File Relationships

| URL                                               | Status | Request builder | Structured type |
|---------------------------------------------------|:------:|:---------------:|:---------------:|
| /manage_file_relationships/get_file_relationships |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/get_potentials_count   |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/get_potential_pairs    |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/get_random_potentials  |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/remove_potentials      |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/set_file_relationships |   ✅    |        ❌        |        ❌        |
| /manage_file_relationships/set_kings              |   ✅    |        ❌        |        ❌        |

### Managing Services

| URL                                 | Status | Request builder | Structured type |
|-------------------------------------|:------:|:---------------:|:---------------:|
| /manage_services/get_pending_counts |   ✅    |        ❌        |        ❌        |
| /manage_services/commit_pending     |   ✅    |        ❌        |        ❌        |
| /manage_services/forget_pending     |   ✅    |        ❌        |        ❌        |

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
| /manage_pages/get_pages     |   ❌    |        ❌        |        ❌        |
| /manage_pages/get_page_info |   ❌    |        ❌        |        ❌        |
| /manage_pages/add_files     |   ❌    |        ❌        |        ❌        |
| /manage_pages/focus_page    |   ❌    |        ❌        |        ❌        |
| /manage_pages/refresh_page  |   ❌    |        ❌        |        ❌        |

### Managing Popups

| URL                                     | Status | Request builder | Structured type |
|-----------------------------------------|:------:|:---------------:|:---------------:|
| /manage_popups/get_popups               |   ❌    |        ❌        |        ❌        |
| /manage_popups/add_popup                |   ❌    |        ❌        |        ❌        |
| /manage_popups/call_user_callable       |   ❌    |        ❌        |        ❌        |
| /manage_popups/cancel_popup             |   ❌    |        ❌        |        ❌        |
| /manage_popups/dismiss_popup            |   ❌    |        ❌        |        ❌        |
| /manage_popups/finish_popup             |   ❌    |        ❌        |        ❌        |
| /manage_popups/finish_and_dismiss_popup |   ❌    |        ❌        |        ❌        |
| /manage_popups/update_popup             |   ❌    |        ❌        |        ❌        |

### Managing the Database

| URL                                 | Status | Request builder | Structured type |
|-------------------------------------|:------:|:---------------:|:---------------:|
| /manage_database/force_commit       |   ❌    |        ❌        |        ❌        |
| /manage_database/lock_on            |   ❌    |        ❌        |        ❌        |
| /manage_database/lock_off           |   ❌    |        ❌        |        ❌        |
| /manage_database/mr_bones           |   ❌    |        ❌        |        ❌        |
| /manage_database/get_client_options |   ❌    |        ❌        |        ❌        |

## Future plans:

- Other API request
- Requests builder
- Structured types for response
