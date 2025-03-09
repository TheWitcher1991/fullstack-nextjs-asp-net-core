import { HTTP } from '~packages/lib'
import links from '~packages/links'
import { API_URL } from '~packages/system'

const config = {
	baseURL: `${API_URL}/`,
	withCredentials: true,
	xsrfCookieName: 'csrftoken',
	xsrfHeaderName: 'X-CSRFToken',
	timeoutErrorMessage: 'Превышено время ожидания ответа от сервера',
	headers: {
		'Content-Type': 'application/json',
		'X-Requested-With': 'XMLHttpRequest',
		Accept: 'application/json',
	},
}

export const http = new HTTP({
	config: config,
	onRequest: (config: any) => {
		const access_token = ''
		const token_type = 'Bearer'
		if (access_token) {
			config.headers.Authorization = `${token_type} ${access_token}`
		}
		return config
	},
	onRejected: async (error: any) => {
		const originalRequest = error.config

		if (!error.response) {
			return Promise.reject(error)
		}

		if (error.response.status === 401 && !originalRequest._retry) {
			originalRequest._retry = true
			try {
				const _http = HTTP.create(config)

				// const response = await AuthRepository.refresh()

				// const newAccessToken = response.data.access_token

				// login({
				// 	access_token: newAccessToken,
				//	access_expires: response.data.access_expires,
				// })

				return _http(originalRequest)
			} catch (refreshError) {
				// logout()
				window.location.replace(links.login)
				return Promise.reject(refreshError)
			}
		}

		return Promise.reject(error)
	},
})
