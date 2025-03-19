import { AxiosInstance, AxiosResponse } from 'axios'

import { calcPercent, prepareRequestParams } from '~packages/utils'

import { BaseRepository } from './base'

export class CrudRepository<
	LIST_GET,
	GET,
	CREATE,
	UPDATE,
	OPTIONS = Record<string, any>,
> extends BaseRepository {
	constructor(
		readonly http: AxiosInstance,
		readonly URL: string,
	) {
		super(http, URL)
	}

	async all(
		params?: Partial<OPTIONS>,
	): Promise<AxiosResponse<ResultResponse<LIST_GET>>> {
		return await this.instance.get(`${this.URL}`, {
			params: prepareRequestParams(params),
		})
	}

	async getById(id: string): Promise<AxiosResponse<ResultResponse<GET>>> {
		return await this.instance.get(`${this.URL}/${id}`)
	}

	async create(data: CREATE): Promise<AxiosResponse<GET>> {
		return await this.instance.post<GET>(`${this.URL}`, data)
	}

	async createFormData(
		data: FormData,
		onUploadProgress?: OnUploadProgress,
	): Promise<AxiosResponse<GET>> {
		return await this.instance.post<GET>(`${this.URL}`, data, {
			headers: {
				'Content-Type': 'multipart/form-data',
			},
			onUploadProgress: progressEvent => {
				onUploadProgress?.(
					calcPercent(progressEvent.loaded, progressEvent.total),
					progressEvent.loaded / 1024 / 1024,
					progressEvent.total / 1024 / 1024,
				)
			},
		})
	}

	async update(
		id: string,
		data: Partial<UPDATE>,
	): Promise<AxiosResponse<GET>> {
		return await this.instance.patch<GET>(`${this.URL}/${id}`, data)
	}

	async updateFormData(
		id: string,
		data: FormData,
		onUploadProgress?: OnUploadProgress,
	): Promise<AxiosResponse<GET>> {
		return await this.instance.put<GET>(`${this.URL}/${id}`, data, {
			headers: {
				'Content-Type': 'multipart/form-data',
			},
			onUploadProgress: progressEvent => {
				onUploadProgress?.(
					calcPercent(progressEvent.loaded, progressEvent.total),
					progressEvent.loaded / 1024 / 1024,
					progressEvent.total / 1024 / 1024,
				)
			},
		})
	}

	async delete(id: string): Promise<AxiosResponse<any>> {
		return await this.instance.delete(`${this.URL}/${id}`)
	}
}
