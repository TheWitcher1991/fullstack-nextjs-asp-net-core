import { useMutation } from '@tanstack/react-query'

import { impressionServiceKeys } from '~models/impression/impression.config'
import { ImpressionRepository } from '~models/impression/impression.repository'
import {
	ICreateImpression,
	IUpdateImpression,
} from '~models/impression/impression.types'

import { optimisticInvalidateQueries } from '~packages/lib'

export const useCreateImpression = () => {
	return useMutation({
		mutationFn: (data: ICreateImpression) =>
			ImpressionRepository.create(data),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[impressionServiceKeys.impressions],
				[impressionServiceKeys.impressionsByBook],
				[impressionServiceKeys.impressionsByUser],
			])
		},
	})
}

export const useUpdateImpression = (id: string) => {
	return useMutation({
		mutationFn: (data: IUpdateImpression) =>
			ImpressionRepository.update(id, data),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[impressionServiceKeys.impression, id],
				[impressionServiceKeys.impressions],
				[impressionServiceKeys.impressionsByBook],
				[impressionServiceKeys.impressionsByUser],
			])
		},
	})
}

export const useDeleteImpression = () => {
	return useMutation({
		mutationFn: (id: string) => ImpressionRepository.delete(id),
		onSettled: async () => {
			await optimisticInvalidateQueries([
				[impressionServiceKeys.impressions],
				[impressionServiceKeys.impressionsByBook],
				[impressionServiceKeys.impressionsByUser],
			])
		},
	})
}
