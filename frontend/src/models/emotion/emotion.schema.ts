import { z } from 'zod'

import { zShape } from '~packages/schemas'

export const BaseEmotionSchema = z.object({
	label: z.string().max(50),
	name: z.string().max(50),
	unicode: z.string().max(1),
})

export const EmotionSchema = BaseEmotionSchema.extend({
	id: zShape.id,
})
