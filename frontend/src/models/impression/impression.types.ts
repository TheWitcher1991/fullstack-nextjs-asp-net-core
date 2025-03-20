import { z } from 'zod'

import {
	CreateImpressionSchema,
	ImpressionSchema,
	ImpressionUserSchema,
	UpdateImpressionSchema,
} from '~models/impression/impression.schema'

export type IImpression = z.infer<typeof ImpressionSchema>

export type IImpressionUser = z.infer<typeof ImpressionUserSchema>

export type ICreateImpression = z.infer<typeof CreateImpressionSchema>

export type IUpdateImpression = z.infer<typeof UpdateImpressionSchema>

export type UseImpressions = UseModelOptions
