# Dockerfile for production mode

#
# ---------------------------------------------------------
#
FROM node:20-alpine AS base

ARG NEXT_PUBLIC_API_URL

ENV DIR=/home/frontend \
    COREPACK_INTEGRITY_KEYS="0" \
    PNPM_HOME="/pnpm" \
    PATH="$PNPM_HOME:$PATH"

RUN corepack enable pnpm
RUN corepack use pnpm@10.0.0

#
# ---------------------------------------------------------
#
FROM base AS deps

RUN apk add --no-cache libc6-compat

WORKDIR $CLIENT_DIR

COPY package.json yarn.lock* package-lock.json* pnpm-lock.yaml* .npmrc* ./

RUN --mount=type=cache,id=pnpm,target=/pnpm/store pnpm install --frozen-lockfile

#
# ---------------------------------------------------------
#
FROM base AS builder

WORKDIR $CLIENT_DIR

COPY --from=deps $CLIENT_DIR/node_modules ./node_modules
COPY . .

RUN pnpm prebuild

RUN pnpm build

#
# ---------------------------------------------------------
#
FROM base AS runner

WORKDIR $CLIENT_DIR

ENV NODE_ENV=production

RUN addgroup --system --gid 1001 nodejs
RUN adduser --system --uid 1001 nextjs

COPY --from=builder --chown=nextjs:nodejs $CLIENT_DIR/public ./public
COPY --from=builder --chown=nextjs:nodejs $CLIENT_DIR/package.json ./package.json
COPY --from=builder --chown=nextjs:nodejs $CLIENT_DIR/.next ./.next
COPY --from=builder --chown=nextjs:nodejs $CLIENT_DIR/node_modules ./node_modules

USER nextjs

EXPOSE 3000

CMD ["pnpm", "start"]
